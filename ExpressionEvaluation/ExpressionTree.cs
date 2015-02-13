using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression_Evaluation
{
    public class ExpressionTree
    {
        //the tree that hold the expression. Also has the ability to evaluate it as well.
        //Need to be able to do : addition, subtraction, multiplication, division, power.
        // Need to support : variables and its definition (via dictionary)
        // Critical support : correct order of execution with parenthesis.
        //i.e : ((x -7) * 4^2) / ( 16 - (7 +2))  + 7^2

        //Tactics:
        //Scan the expression, break it down to pieces. 
        // ((x-7) * 4^2), "/" , "(16-(7+2))", "+",   "7"  , "^"   , "2"
        //    <somevar>   <op>   <somevar>    <op>  <var>   <op>   <var>
        //               <somevar>            <op>       <somevar>

        //class variables
        private Node root;              //root node of the tree.
        private Dictionary<string, double> variable_dictionary;     //dictionary that hold the variables and its value
        private string current_expression;


        //constructors
        public ExpressionTree()
        {
            //default constructor.
            root = null;
            variable_dictionary = new Dictionary<string, double>();
            current_expression = string.Empty;
        }

        public ExpressionTree(Node the_root, Dictionary<string, double> var_dict, string expression)
        {
            //overload #1
            root = the_root;
            variable_dictionary = var_dict;
            current_expression = expression;
        }

        //methods

        //getters and setters
        public Node Root
        {
            get { return root; }
            private set { root = value; }
        }

        public Dictionary<string, double> Variable_Dictionary
        {
            get { return variable_dictionary; }
            private set { variable_dictionary = value; }
        }

        internal string Current_Expression_v2
        {
            get { return current_expression; }
            set
            {
                current_expression = value;

            }

        }

        public void set_new_expression(string exp)
        {
            //reset the root.
            root = null;

            //update new expression
            current_expression = exp;
            //build the new tree upon the current instance
            root = TreeBuilder(current_expression).Root;
        }

        //Variable dictionary modifier
        //Add new variables
        public void add_new_variable(string var, double var_value)
        {
            //add new variable value into the dictionary.
            variable_dictionary[var] = var_value;
        }


        //helpers, internal.

        public static List<string> expression_breakdown(string expression)
        {
            //Break down the expression into the workable pieces
            //accepting an expression under a string, and break it down into pieces.
            if (expression[0] == '(' && expression[expression.Length - 1] == ')')
            {
                expression = expression.Substring(1, expression.Length - 2);
            }
            List<string> tokens = new List<string>();
            char[] op_list = { '+', '-', '*', '/', '^' };
            int last_known_var_index = 0;
            int paren_counter = 0;

            for (int i = 0; i < expression.Length; i++)
            {

                if (expression[i] == '(')
                {
                    paren_counter++;
                }

                else if (expression[i] == ')')
                {
                    paren_counter--;
                }

                else if (true == op_list.Contains(expression[i]) && paren_counter == 0)
                {
                    // it is an op
                    //the var before it.
                    string to_be_added = expression.Substring(last_known_var_index, i - last_known_var_index).Trim();      //remove all the trailing spaces, both front and tail.
                    tokens.Add(to_be_added);
                    tokens.Add(expression[i].ToString());               //add the current op to the list.

                    last_known_var_index = i + 1;

                }
            }

            //for-loop ended, get the last element in.
            tokens.Add(expression.Substring(last_known_var_index, expression.Length - last_known_var_index).Trim());

            tokens.Remove("");

            return tokens;
        }

        //Static Building methods

        public static ExpressionTree TreeBuilder(string expression)
        {
            //Static method accept an expression as a string and return a reference to a newly built tree according to that expression

            //expected to have in the string : variable (x, y...) , operator (+ -) , constant (numbers)

            //workable is the list that hold all the tokens that are actionable from the expression.


            List<string> workable = expression_breakdown(expression);
            //i.e : ((x -7) * 4^2) / ( 16 - (7 +2))  + 7^2
            //expected workable to be : [ "((x -7) * 4^2)", "/", "( 16 - (7 +2))", "+", "7", "^", "2"]

            if (workable.Count == 1)
            {
                //only 1 variable in the list.
                //Only 2 possible cases

                double value = 0;

                if (double.TryParse(workable[0], out value))
                {
                    //Case 1: A constant. (i.e convertion to double is a sucess.
                    ExpressionTree a_tree = new ExpressionTree();
                    a_tree.Root = new Constant_Node(value);
                    a_tree.Current_Expression_v2 = workable[0];
                    return a_tree;
                }


                else
                {
                    //Case 2: A variable.
                    ExpressionTree a_tree = new ExpressionTree();
                    a_tree.root = new Variable_Node(workable[0]);
                    a_tree.Current_Expression_v2 = workable[0];
                    return a_tree;
                }
            }

            else if (workable.Count > 1)
            {
                //have value to play with.
                //Adjust the workable list to find out which operation would be the last to be evaluated , to create the root.

                //string of operations, from lower-priority to higher-priority
                //for (int i = 0 ; i < workable.Count;i++)
                //{
                //    if (workable[i][0] == '(' && workable[i][workable[i].Length-1] == ')')
                //    {
                //        workable[i] = workable[i].Substring(1, workable[i].Length - 2);
                //    }
                //}
                string[] ops = { "+", "-", "*", "/", "^" };

                foreach (string op in ops)
                {
                    //going from left to right of the ops array, so the top-most will always be lower-priority op
                    for (int i = workable.Count - 1; i >= 0; i--)
                    {
                        //going backward on the workable list/expression, to make the expression be created in the way that promote left to right evaluation.
                        if (op != "^")
                        {
                            if (op == workable[i])
                            {
                                ExpressionTree a_tree = new ExpressionTree();
                                a_tree.Root = new Operation_Node(workable[i]);
                                a_tree.Current_Expression_v2 = expression;

                                //right_child is the rest on the right.
                                StringBuilder my_builder_left = new StringBuilder();
                                for (int a = i + 1; a < workable.Count; a++)
                                {
                                    my_builder_left.Append(workable[a]);
                                }
                                a_tree.Root.Right_Child = TreeBuilder(my_builder_left.ToString()).Root;

                                //left child the rest of the left.
                                StringBuilder my_builder_right = new StringBuilder();

                                for (int a = 0; a < i; a++)
                                {
                                    my_builder_right.Append(workable[a]);
                                }

                                a_tree.Root.Left_Child = TreeBuilder(my_builder_right.ToString()).Root;

                                return a_tree;

                            }
                        }
                        else
                        {
                            //operator is power sign, right associative, special case
                            if (op == workable[i])
                            {
                                //because the power sign is right associative, scan futher to the left to see if any "next-to" power sign is there.
                                int index_pow = i;

                                while ((i - 2) >= 0 && workable[i - 2] == op)
                                {
                                    i = i - 2;
                                }

                                //i now will either hold the old value, or the new calculated value.
                                ExpressionTree a_tree = new ExpressionTree();
                                a_tree.Root = new Operation_Node(workable[i]);
                                a_tree.Current_Expression_v2 = expression;

                                //right_child is the rest on the right.
                                StringBuilder my_builder_left = new StringBuilder();
                                for (int a = i + 1; a < workable.Count; a++)
                                {
                                    my_builder_left.Append(workable[a]);
                                }
                                a_tree.Root.Right_Child = TreeBuilder(my_builder_left.ToString()).Root;

                                //left child the rest of the left.
                                StringBuilder my_builder_right = new StringBuilder();

                                for (int a = 0; a < i; a++)
                                {
                                    my_builder_right.Append(workable[a]);
                                }

                                a_tree.Root.Left_Child = TreeBuilder(my_builder_right.ToString()).Root;

                                return a_tree;


                            }
                        }

                    }
                }


            }

            //if somehow get here, return null because of all the method has failed.
            return null;
        }

        public double Evaluation()
        {
            //evaluation
            return Evaluation_v2(root);
        }

        internal double Evaluation_v2(Node the_node)
        {
            if (the_node.node_type == "variable")
            {
                double result;
                if (variable_dictionary.TryGetValue(the_node.Expression, out result))
                {
                    //if the value is there, resturn the result.
                    return result;
                }

                else
                {
                    //not found
                    return 0;
                }
            }

            else if (the_node.node_type == "constant")
            {
                //just a variable , return the value
                return (the_node as Constant_Node).Constant_Evaluated;
            }

            else
            {
                //Expression type

                string op = the_node.Expression;

                switch (op)
                {
                    case "+":
                        return Evaluation_v2(the_node.Left_Child) + Evaluation_v2(the_node.Right_Child);
                    case "-":
                        return Evaluation_v2(the_node.Left_Child) - Evaluation_v2(the_node.Right_Child);
                    case "*":
                        return Evaluation_v2(the_node.Left_Child) * Evaluation_v2(the_node.Right_Child);
                    case "/":
                        return Evaluation_v2(the_node.Left_Child) / Evaluation_v2(the_node.Right_Child);
                    case "^":
                        return Math.Pow(Evaluation_v2(the_node.Left_Child), Evaluation_v2(the_node.Right_Child));
                }

                return 0.0;
            }



        }

        public List<string> vars_list(Node the_node)
        {
            //Return a list contain all variables in the given tree/tree root.
            if (the_node.node_type != "variable")
            {
                List<string> left_list = new List<string>();
                List<string> right_list = new List<string>();
                if (the_node.Left_Child != null)
                {
                    left_list = vars_list(the_node.Left_Child);
                }

                if (the_node.Right_Child != null)
                {
                    right_list = vars_list(the_node.Right_Child);
                }

                foreach (string item in right_list)
                {
                    left_list.Add(item);
                }

                return left_list;

            }

            else
            {
                //base case.
                return new List<string>() { the_node.Expression };
            }


        }
    }
}
