using FluentAssertions;
using SilentGuardian.Domain.Checks;

namespace SilentGuardian.xUnitTests;

public class CheckMethodsUnitTests
{
    [Theory]
    [InlineData("192.168.1.1", 29070, 200, null)]
    [InlineData("192.168.1.1.58", 29070, 200, typeof(ArgumentException))]
    [InlineData("192.168.1.1", 66565, 200, typeof(ArgumentOutOfRangeException))]
    public void TcpPortCreation(string ip, int port,int timeout, Type? expectedException)
    {
        Action act = () => TcpPortCheck.Create(ip, port,timeout);
        
        if (expectedException == null)
        {
            var check = TcpPortCheck.Create(ip, port);
            
            check.Should().NotBeNull();
            check.Port.Should().Be(port);
            check.IP.Should().Be(ip);
        }
        else
        {
            act.Should().Throw<Exception>()
                .Where(e => e.GetType() == expectedException);
        }
    }
}