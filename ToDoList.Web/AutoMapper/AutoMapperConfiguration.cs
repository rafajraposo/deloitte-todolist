using AutoMapper;
using ToDoList.Entity;
using ToDoList.Web.Models;

namespace ToDoList.Web.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<Item, ToDoCreateViewModel>().ReverseMap();
                c.CreateMap<Item, ToDoEditViewModel>().ReverseMap();
            });
        }
    }
}