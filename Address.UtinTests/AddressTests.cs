using TestAssig;

namespace Address.UtinTests
{
    public class AddressTests
    {
        [Theory]
        [InlineData(0,"255.255.255.255")]
        [InlineData(1,"127.255.255.255")]
        [InlineData(2,"63.255.255.255")]
        [InlineData(3,"31.255.255.255")]
        [InlineData(4,"15.255.255.255")]
        [InlineData(5,"7.255.255.255")]
        [InlineData(6,"3.255.255.255")]
        [InlineData(7,"1.255.255.255")]
        [InlineData(8,"0.255.255.255")]
        [InlineData(9,"0.127.255.255")]
        [InlineData(10,"0.63.255.255")]
        [InlineData(11,"0.31.255.255")]
        [InlineData(12,"0.15.255.255")]
        [InlineData(13,"0.7.255.255")]
        [InlineData(14,"0.3.255.255")]
        [InlineData(15,"0.1.255.255")]
        [InlineData(16,"0.0.255.255")]
        [InlineData(17,"0.0.127.255")]
        [InlineData(18,"0.0.63.255")]
        [InlineData(19,"0.0.31.255")]
        [InlineData(20,"0.0.15.255")]
        [InlineData(21,"0.0.7.255")]
        [InlineData(22,"0.0.3.255")]
        [InlineData(23,"0.0.1.255")]
        [InlineData(24,"0.0.0.255")]
        [InlineData(25,"0.0.0.127")]
        [InlineData(26,"0.0.0.63")]
        [InlineData(27,"0.0.0.31")]
        [InlineData(28,"0.0.0.15")]
        [InlineData(29,"0.0.0.7")]
        [InlineData(30,"0.0.0.3")]
        [InlineData(31,"0.0.0.1")]
        [InlineData(32,"0.0.0.0")]
        public void AddressMask_GetMaxAddress_MaxAddress(int value1, string value2)
        {
            var result = AddressHelper.GetMaxAddress(value1);

            Assert.Equal(value2, result);
        }
    }
}