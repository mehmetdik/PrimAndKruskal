using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12253021HW4
{
    class Edge : IComparable
    {
        string homeVertexId;

        public string HomeVertexId
        {
            get { return homeVertexId; }
            set { homeVertexId = value; }
        }

        string vertexId;

        public string VertexId
        {
            get { return vertexId; }
            set { vertexId = value; }
        }
        int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        Edge next;

        internal Edge Next
        {
            get { return next; }
            set { next = value; }
        }
        public Edge(string id, int w, string HomeVertexId)
        {
            vertexId = id;
            weight = w;
            homeVertexId = HomeVertexId;
        }
        public override string ToString()
        {
            return vertexId + " ";// + weight.ToString();
        }
        public int CompareTo(object obj)
        {
            Edge std = (Edge)obj;
            if (this.Weight > std.Weight)
                return 1;
            else if (this.Weight < std.Weight)
                return -1;
            else
                return 0;
        }
    }
}
