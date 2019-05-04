using NUnit.Framework;

namespace JSONToDictionary.Tests
{
    [TestFixture]
    public class SimpleObject
    {
        [Test]
        public void String() {
            var json = "{name:'Jon'}";
            var dictionary = JSONToDictionary.ToDictionary(json);
            Assert.That(dictionary["name"], Is.EqualTo("Jon"));
        }

        [Test]
        public void Integer()
        {
            var json = "{age:33}";
            var dictionary = JSONToDictionary.ToDictionary(json);
            Assert.That(dictionary["age"], Is.EqualTo(33));
        }

        [Test]
        public void Decimal()
        {
            var json = "{length:178.5}";
            var dictionary = JSONToDictionary.ToDictionary(json);
            Assert.That(dictionary["length"], Is.EqualTo(178.5));
        }


        [Test]
        public void Boolean()
        {
            var json = "{married:true}";
            var dictionary = JSONToDictionary.ToDictionary(json);
            Assert.That(dictionary["married"], Is.EqualTo(true));
        }

        [Test]
        public void Combined()
        {
            var json = @"{
                            name:'Jon',
                            age:33,
                            length:178.5,
                            married:true,
                       }";
            var dictionary = JSONToDictionary.ToDictionary(json);

            Assert.That(dictionary["name"], Is.EqualTo("Jon"));
            Assert.That(dictionary["age"], Is.EqualTo(33));
            Assert.That(dictionary["length"], Is.EqualTo(178.5));
            Assert.That(dictionary["married"], Is.EqualTo(true));
        }
    }
}
