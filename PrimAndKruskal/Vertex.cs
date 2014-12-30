using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12253021HW4
{
    class Vertex : IComparable
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        Vertex next;

        internal Vertex Next
        {
            get { return next; }
            set { next = value; }
        }
        Edge edgeLink;

        internal Edge EdgeLink
        {
            get { return edgeLink; }
            set { edgeLink = value; }
        }
        public Vertex(string id)
        {
            this.id = id;
        }
        public override string ToString()
        {
            return id;
        }

        public int CompareTo(Object obj)
        {
            Vertex std = (Vertex)obj;
            return 0;
        }
    }
}
