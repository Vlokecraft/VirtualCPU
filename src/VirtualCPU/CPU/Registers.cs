namespace VirtualCPU.CPU
{
    public class Registers
    {
        public byte ACC { get; set; } = 0;
        public byte R0 { get; set; } = 0;
        public byte R1 { get; set; } = 0;
        public byte R2 { get; set; } = 0;
        public byte R3 { get; set; } = 0;
        public byte R4 { get; set; } = 0;
        public byte R5 { get; set; } = 0;
        public byte R6 { get; set; } = 0;
        public byte R7 { get; set; } = 0;
        public byte PC { get; set; } = 0;

        public byte FetchR(byte index)
        {
            switch (index)
            {
                case 0x00: return R0;
                case 0x01: return R1;
                case 0x02: return R2;
                case 0x03: return R3;
                case 0x04: return R4;
                case 0x05: return R5;
                case 0x06: return R6;   
                case 0x07: return R7;
                default: throw new ArgumentException("Invalid register index");      
            }
        }
        public void LoadR(byte index, byte value)
        {
            switch (index)
            {
                case 0x00: R0 = value; break;
                case 0x01: R1 = value; break;
                case 0x02: R2 = value; break;
                case 0x03: R3 = value; break;
                case 0x04: R4 = value; break;
                case 0x05: R5 = value; break;
                case 0x06: R6 = value; break;
                case 0x07: R7 = value; break;
                default: throw new ArgumentException("Invalid register index");
            }
        }
    }
}