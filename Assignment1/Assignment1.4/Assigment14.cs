using System;
using System.Collections.Generic;

namespace Assignment1._4
{
        abstract class Expr
        {
            abstract public int Eval(Dictionary<string, int> env);
        }

        class CstI : Expr
        {
            protected readonly int I;

            public CstI(int i) { I = i; }

            public override int Eval(Dictionary<string, int> env)
            {
                return I;
            }
        }

        class Var : Expr
        {
            protected readonly string Name;

            public Var(string name) { Name = name; }

            public override int Eval(Dictionary<string,int> env) {
                return env[Name];
            }
        }


        class Prim : Expr
        {
            protected readonly string Oper;
            protected readonly Expr E1, E2;

            public Prim(string oper, Expr e1, Expr e2) { Oper = oper; E1 = e1; E2 = e2; }

            public override int Eval(Dictionary<string,int> env)
            {
                if (Oper.Equals("+")) return E1.Eval(env) + E2.Eval(env);
                if (Oper.Equals("*")) return E1.Eval(env) * E2.Eval(env);
                if (Oper.Equals("-"))return E1.Eval(env) - E2.Eval(env);

                throw new ArgumentException("unknown primitive");
            }
        }
}
