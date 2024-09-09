namespace RedactionService.Tests;

public class RedactionServiceTests
{
    [Fact]
    public void TestRedaction()
    {
        var redactionWords = new[] { "Dog", "Cat", "Snake", "Dolphin", "Mammal" };
        var service = new RedactApi.Services.RedactionService(redactionWords);

        var input = "A dog, a monkey or a dolphin are all mammals.";
        var expected = "A REDACTED, a monkey or a REDACTED are all mammals.";

        var result = service.RedactText(input);

        Assert.Equal(expected, result);
    }
}
