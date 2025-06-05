namespace VirtualCPU.Memory
{
    public class Memory
    {
        public readonly byte[] _data;

        public Memory(int size)
        {
            _data = new byte[size];
        }

        public byte ReadByte(int address) => _data[address];
        public void WriteByte(int address, byte value) => _data[address] = value;

        public byte[] ReadBytes(int address, int length)
        {
            if (address < 0 || address + length > _data.Length)
                throw new ArgumentOutOfRangeException($"Read of {length} bytes at {address} exceeds memory bounds.");
            byte[] output = new byte[length];
            Array.Copy(_data, address, output, 0, length);
            return output;
        }

        public void WriteBytes(int address, byte[] values)
        {
            int length = values.Length;
            if (address < 0 || address + length > _data.Length)
                throw new ArgumentOutOfRangeException($"Write of {length} bytes at {address} exceeds memory bounds.");
            Array.Copy(values, 0, _data, address, length);
        }
    }
}