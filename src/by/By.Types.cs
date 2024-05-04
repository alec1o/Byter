namespace Byter
{
    public partial class By : IBy
    {
        /// <summary>
        /// -45
        /// </summary>
        private const sbyte TypesPrefix =
        (
            // XXXTentacion: Jahseh Dwayne Ricardo Onfroy
            // January 23, 1998 - June 18, 2018 (age 20 years)
            +(01 + 23 + 1998) - (06 + 18 + 2018)
            // Juice WRLD: Jarad Anthony Higgins
            // December 2, 1998 - December 8, 2019 (age 21 years)
            + (12 + 2 + 1998) - (12 + 06 + 2019)
        );

        enum Types
        {
            // 1 byte
            Sbyte = TypesPrefix + 1,
            Byte = TypesPrefix + 2,
            Bool = TypesPrefix + 3,

            // 2 bytes
            Char = TypesPrefix + 4,
            Short = TypesPrefix + 5,
            Ushort = TypesPrefix + 6,

            // 4 bytes
            Uint = TypesPrefix + 7,
            Int = TypesPrefix + 8,
            Float = TypesPrefix + 9,
            Enum = TypesPrefix + 10,

            // 8 bytes
            Long = TypesPrefix + 11,
            Ulong = TypesPrefix + 12,
            Double = TypesPrefix + 13,

            // 16 bytes
            Decimal = TypesPrefix + 14,

            // dynamic
            Bytes = TypesPrefix + 15,
            String = TypesPrefix + 16,
            BigInteger = TypesPrefix + 18,

            // Symbols
            Class = TypesPrefix + 19,
            Struct = TypesPrefix + 20,
            Array = TypesPrefix + 21,
        };
    }
}