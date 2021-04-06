using System;

namespace MIPSish
{
    public class Register
    {
        private readonly int _index;

        public Register(int index)
        {
            _index = index;
        }

        public static explicit operator int(Register r) => r._index;
        public static implicit operator Register(int i) => new Register(i);
    }

    public static class Asm
    {
        public static readonly Register v0 = 2, v1 = 3;
        public static readonly Register a0 = 4, a1 = 5, a2 = 6, a3 = 7;
        public static readonly Register t0 = 8, t1 = 9, t2 = 10, t3 = 11, t4 = 12,
                                        t5 = 13, t6 = 14, t7 = 15, t8 = 24, t9 = 25;
        public static readonly Register s0 = 16, s1 = 17, s2 = 18, s3 = 19, s4 = 20,
                                        s5 = 21, s6 = 22, s7 = 23;
        public static readonly Register sp = 29;
        public static readonly Register fp = 30;
        public static readonly Register ra = 31;

        private static int[] _reg = new int[32];

        public static void li(Register destRegister, int value)
        {
            _reg[(int)destRegister] = value;
        }

        public static void add(Register destRegister, Register register1, Register register2)
        {
            _reg[(int)destRegister] = _reg[(int)register1] + _reg[(int)register2];
        }

        public static void addi(Register destRegister, Register register, int value)
        {
            _reg[(int)destRegister] = _reg[(int)register] + value;
        }

        public static void move(Register destRegister, Register sourceRegister)
        {
            _reg[(int)destRegister] = _reg[(int)sourceRegister];
        }

        public static bool beq(Register register1, Register register2)
        {
            return _reg[(int)register1] == _reg[(int)register2];
        }

        public static bool beq(Register register, int value)
        {
            return _reg[(int)register] == value;
        }

        public static void syscall()
        {
            switch (_reg[(int)v0])
            {
                case 1:
                    Console.WriteLine(_reg[(int)a0]);
                    break;
                case 5:
                    var input = Console.ReadLine();
                    _reg[(int)v0] = int.Parse(input);
                    break;
                case 10:
                    Environment.Exit(0);
                    break;
                default:
                    throw new NotImplementedException("¯\\_(ツ)_/¯");
            }
        }
    }
}