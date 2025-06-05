using System.Runtime.CompilerServices;
using VirtualCPU.Memory;

namespace VirtualCPU.CPU
{
    public class ControlUnit
    {
        public readonly Memory.Memory _memory;
        public readonly Registers _registers;
        private bool _running;

        public ControlUnit(Memory.Memory memory)
        {
            _memory = memory;
            _registers = new Registers();
            _running = true;
        }

        public void Run()
        {
            while (_running) // This isn't very good. This should be running on the clock, but hey.
            {
                // Single Byte Logic (for now)
                byte opcode = _memory.ReadByte(_registers.PC);
                byte operand = _memory.ReadByte(_registers.PC++);
                byte operand2;

                switch (opcode)
                {
                    case 0x00: // NO OPERATION
                        break;
                    case 0x01: // LOAD ACC
                        _registers.ACC = _memory.ReadByte(operand);
                        break;
                    case 0x02: // LOAD R, MEM
                        operand2 = _memory.ReadByte(_registers.PC++);
                        _registers.LoadR(operand, operand2);
                        break;
                    case 0x03: // STORE ACC
                        _memory.WriteByte(operand, _registers.ACC);
                        break;
                    case 0x04: // STORE R, MEM
                        operand2 = _memory.ReadByte(_registers.PC++);
                        _memory.WriteByte(operand, _registers.FetchR(operand2));
                        break;
                    case 0x05: // MOVE R1,R2
                        operand2 = _memory.ReadByte(_registers.PC++);
                        _registers.LoadR(operand, _registers.FetchR(operand2));
                        break;
                    case 0x06: // ADD MEM
                        _registers.ACC += _memory.ReadByte(operand);
                        break;
                    case 0x07: // ADD R
                        _registers.ACC += _registers.FetchR(operand);
                        break;
                    case 0x08: // SUB MEM
                        _registers.ACC -= _memory.ReadByte(operand);
                        break;
                    case 0x09: // SUB R
                        _registers.ACC -= _registers.FetchR(operand);
                        break;
                    case 0x0A: // INC R
                        operand2 = _registers.FetchR(operand);
                        operand2++;
                        _registers.LoadR(operand, operand2);
                        break;
                    case 0x0B: // DEC R
                        operand2 = _registers.FetchR(operand);
                        operand2++;
                        _registers.LoadR(operand, operand2);
                        break;
                }
            }
        }
    }
}