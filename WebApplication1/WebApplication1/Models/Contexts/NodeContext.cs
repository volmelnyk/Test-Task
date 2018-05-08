using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace WebApplication1
{
    public class NodeContext:DbContext
    {
        public NodeContext() : base("DefaultConnection")
        {

        }
        public DbSet<Node> Nodes { get; set; }
    }
}
