using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codevist.Blockchain.Demo.Models
{
    public class BlockChainModel
    {
        public int Nonce { get; set; }
        public string Data { get; set; }
        public string Prev { get; set; }
        public string Hash { get; set; }
    }
}