using System;
using System.Collections.Generic;
using System.Text;

namespace Day8
{
    internal class InstructionType : IEquatable<InstructionType>
    {
        public string Value { get; set; }

        public InstructionType(string value)
        {
            Value = value.ToLower();
        }

        public static InstructionType nop { get { return new InstructionType("nop"); } }
        public static InstructionType acc { get { return new InstructionType("acc"); } }
        public static InstructionType jmp { get { return new InstructionType("jmp"); } }

        public override bool Equals(object obj)
        {
            return Equals(obj as InstructionType);
        }

        public bool Equals(InstructionType other)
        {
            return other != null &&
                   Value == other.Value;
        }

        public static bool operator ==(InstructionType lhs, InstructionType rhs)
        {
            // Check for null.
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles the case of null on right side.
            return lhs.Equals(rhs);
        }
        public static bool operator !=(InstructionType lhs, InstructionType rhs)
        {
            return !(lhs==rhs);
        }
    }
}
