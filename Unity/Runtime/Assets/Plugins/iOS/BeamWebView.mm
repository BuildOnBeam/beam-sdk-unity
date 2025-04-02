/*
 * Copyright (C) 2011 Keijiro Takahashi
 * Copyright (C) 2012 GREE, Inc.
 *
 * This software is provided 'as-is', without any express or implied
 * warranty.  In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

#import <Foundation/Foundation.h>
#import <WebKit/WebKit.h>
#import <AuthenticationServices/AuthenticationServices.h>

extern "C" {
    void UnitySendMessage(const char* obj, const char* method, const char* msg);
}

@interface CBeamWebViewPlugin : NSObject<ASWebAuthenticationPresentationContextProviding>
{
    ASWebAuthenticationSession *authSession;
}
- (void)loadUrl:(NSString *)urlString;
- (void)dismiss;
@end

@implementation CBeamWebViewPlugin

- (void)loadUrl:(NSString *)urlString {
    NSURL *url = [NSURL URLWithString:urlString];
    NSString *callbackScheme = NSBundle.mainBundle.bundleIdentifier;
    
    // Clean up existing session if any
    [self dismiss];
    
    authSession = [[ASWebAuthenticationSession alloc]
        initWithURL:url
        callbackURLScheme:callbackScheme
        completionHandler:^(NSURL * _Nullable callbackURL, NSError * _Nullable error) {
            if (error != nil) {
                NSString *errorDetails;
                                if (error.code == ASWebAuthenticationSessionErrorCodeCanceledLogin) {
                                    errorDetails = [NSString stringWithFormat:@"%@|User cancelled", urlString];
                                } else {
                                    errorDetails = [NSString stringWithFormat:@"%@|%@", urlString, error.localizedDescription];
                                }
                                UnitySendMessage("BeamWebView", "HandleError", [errorDetails UTF8String]);
            } else if (callbackURL != nil) {
                UnitySendMessage("BeamWebView", "HandleSuccess", [callbackURL.absoluteString UTF8String]);
            }
            self->authSession = nil;
    }];
    
    authSession.presentationContextProvider = self;
    [authSession start];
}

- (void)dismiss {
    if (authSession != nil) {
        [authSession cancel];
        authSession = nil;
    }
}

- (ASPresentationAnchor)presentationAnchorForWebAuthenticationSession:(ASWebAuthenticationSession *)session {
    return UIApplication.sharedApplication.windows.firstObject;
}

// Unity interface
extern "C" {
    void* _CreateWebView() {
        return (__bridge_retained void*)[[CBeamWebViewPlugin alloc] init];
    }
    
    void _LoadUrl(void* pointer, const char* url) {
        CBeamWebViewPlugin* webView = (__bridge CBeamWebViewPlugin*)pointer;
        [webView loadUrl:[NSString stringWithUTF8String:url]];
    }
    
    void _DismissWebView(void* pointer) {
        CBeamWebViewPlugin* webView = (__bridge CBeamWebViewPlugin*)pointer;
        [webView dismiss];
    }
    
    void _DestroyWebView(void* pointer) {
        if (pointer) {
            CBeamWebViewPlugin* webView = (__bridge_transfer CBeamWebViewPlugin*)pointer;
            [webView dismiss];
        }
    }
}

@end
