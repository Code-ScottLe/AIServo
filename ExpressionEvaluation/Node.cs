using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression_Evaluation
{
    public class Node
    {
        /*
         * Expression can be in type : (x^2 - 3) + (y *7)
         * 
         * We need a node as : Variable (x,y)
         *                      Constant(2,3,7)
         *                      Operator(^,-.+,*)
         * 
         * Each node has : a string that represent the value that it is representing
         *                  a node type to identify the type of node.
         *                  know it left and right child. 
         * */

        //class variables
        internal string expression;              //hold the value in string (not evaluated) 
        internal bool is_empty;             //boolean value, showing the node is empty or not
        public string node_type;        //The node type
        private Node left_child;            //Left child
        private Node right_child;           //Right child

        //constructors
        public Node()
        {
            //default constructor
            expression = string.Empty;
            is_empty = true;
            left_child = null;
            right_child = null;
        }

        //methods

        //getters and setters
        public string Expression
        {
            get { return expression; }
            internal set
            {
                if (value is string)
                {
                    expression = value;
                }

                else
                {
                    expression = value.ToString();
                }
            }
        }

        public bool Is_Empty
        {
            get { return is_empty; }
            internal set { value = is_empty; }

        }

        public Node Left_Child
        {
            get { return left_child; }
            internal set { left_child = value; }
        }

        public Node Right_Child
        {
            get { return right_child; }
            internal set { right_child = value; }
        }


    }

    class Variable_Node : Node
    {
        //Node that is holding a variable.
        //i.e x, y
        //NOTE: This are expression only, please refer to their definition in the dictionary.

        //Contructor
        protected Variable_Node()
            : base()
        {
            //default constructor, hidden from common use.
            node_type = "variable";
        }


        public Variable_Node(string variable_name)
            : base()
        {
            //Constructor for Variable_Node class, accept a string call for the name of the variable.
            Expression = variable_name;
            node_type = "variable";
            Is_Empty = false;
        }

    }

    class Constant_Node : Node
    {
        //Node that is holding a constant
        //i.e 32,45, 64.3
        //Note: because division can result in double/float, using double
        //have one more class var, unique to Constant_Node, call Constant_Evaluated

        //class variables
        private double constant_evaluated;      //hold the evaluated value of the constant (from string)

        //constructors
        protected Constant_Node()
            : base()
        {
            //default constructor, hidden from common use.
            constant_evaluated = 0.0;
            node_type = "constant";

        }

        public Constant_Node(double constant)
            : base()
        {
            //Constructor for Constant_Node class, accept a double/float value under double type
            //Overload #1
            constant_evaluated = constant;
            Expression = constant.ToString();
            node_type = "constant";
            Is_Empty = false;
        }

        public Constant_Node(string constant)
            : base()
        {
            //Constructor for Constant_Node class, accept a string which hold the constant.
            //Overload #2
            if (double.TryParse(constant, out constant_evaluated))
            {
                node_type = "constant";
                Is_Empty = false;
                Expression = constant;
            }

            else
            {
                //fails to convert. throw exception
                throw new InvalidCastException();
            }
        }

        public double Constant_Evaluated
        {
            get { return constant_evaluated; }
            set { constant_evaluated = value; }
        }

    }

    class Operation_Node : Node
    {
        //Node that is holding the Operation.
        //i.e : + - * /

        protected Operation_Node()
            : base()
        {
            //default constructor.
            node_type = "operation";
        }

        public Operation_Node(string op)
            : base()
        {
            //Construction for Operation_Node class, accept a string represent a operation.
            node_type = "operation";
            Expression = op;
            Is_Empty = false;
        }


    }
}
