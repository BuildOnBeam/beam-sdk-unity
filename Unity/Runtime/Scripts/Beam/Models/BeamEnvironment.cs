using System;

namespace Beam.Models
{
    public enum BeamEnvironment
    {
        [Obsolete("Use Production that supports both Mainnet and Testnet chains")]
        Mainnet,
        [Obsolete("Now named Beta, supports only Testnet chains")]
        Testnet,
        Beta,
        Production
    }
}