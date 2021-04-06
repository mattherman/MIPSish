using static MIPSish.Asm;

// Reads a value N from the user and outputs the Nth Fibonnaci number.
// Source: http://rosettacode.org/wiki/Fibonacci_sequence#MIPS_Assembly

main:  li (v0, 5);
       syscall ();

       if (beq(v0, 0)) goto is1;
       if (beq(v0, 1)) goto is1;

       li (s4, 1);

       li (s0, 1);
       li (s1, 1);

loop:  add (s2, s0, s1);
       addi (s4, s4, 1);
       if (beq(v0, s4)) goto iss2;

       add (s0, s1, s2);
       addi (s4, s4, 1);
       if (beq(v0, s4)) goto iss0;

       add (s1, s2, s0);
       addi(s4, s4, 1);
       if (beq(v0, s4)) goto iss1;

       goto loop;

iss0:  move (a0, s0);
       goto print;

iss1:  move (a0, s1);
       goto print;

iss2:  move (a0, s2);
       goto print;

is1:   li (a0, 1);
       goto print;

print: li (v0, 1);
       syscall ();
       li (v0, 10);
       syscall ();