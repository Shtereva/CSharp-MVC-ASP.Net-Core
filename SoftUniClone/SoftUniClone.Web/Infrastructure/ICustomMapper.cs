namespace SoftUniClone.Web.Infrastructure
{
    using AutoMapper;

    public interface ICustomMapper
    {
        void ConfigureMapping(Profile profile);
    }
}
