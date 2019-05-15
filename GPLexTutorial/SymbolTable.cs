using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial
{
    public class SymbolTable
    {
        private SymbolTable parent;
        private Dictionary<string, AST.Declaration> table;

        public SymbolTable(SymbolTable parent)
        {
            this.table = new Dictionary<string, AST.Declaration>();
            this.parent = parent;
        }
        

        public void Add(string identifier, AST.Declaration decl)
        {
            if (table.ContainsKey(identifier))
            {
                throw new ArgumentException(string.Format("Already Defined {0}", identifier));
            }
            else
            {
                table.Add(identifier, decl);
            }

        }

        public AST.Declaration lookUp(string identifier)
        {
            // check if identifier exists in the table, if it does, return that declaration
            bool flag = table.ContainsKey(identifier);


            if (flag)
                return table[identifier];
            else
            {
                if (parent != null)
                {
                    return parent.lookUp(identifier);
                }
                else
                {
                    throw new ArgumentNullException(string.Format("Missing symbol {0}", identifier));
                }


            }
            // otherwise, recursively check the parent
            // if the parent is null, we reached the top, the symbol does not exist. throw an exception
                    }

        public void Dump()
        {
            foreach (var item in table)
            {
                Console.WriteLine("Symbol {0}: {1}", item.Key, item.Value);
            }
        }

    }
}
