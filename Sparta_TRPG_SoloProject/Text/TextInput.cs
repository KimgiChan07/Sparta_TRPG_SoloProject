using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TRPG_SoloProject.TextInput
{
    class _TextInput
    {
        public int InputValue()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (int.TryParse(input.Trim(), out int choice))
                    {
                        return choice;
                    }
                }

            }
        }
    }
}
