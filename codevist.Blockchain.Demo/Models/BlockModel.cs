using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codevist.Blockchain.Demo.Models
{
    public class BlockModel
    {
        public int Nonce { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }
    }
}