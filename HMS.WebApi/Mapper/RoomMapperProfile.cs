using AutoMapper;
using HMS.DTO.Room;
using HMS.Entities;
using HMS.WebApi.Models;

namespace HMS.WebApi.Mapper
{
    public class RoomMapperProfile: Profile
    {
        public RoomMapperProfile()
        {
            CreateMap<RoomDto, Room>()
                .ForMember(e => e.Doctor, opt => opt.Ignore())
                .ForMember(e => e.Patients, opt => opt.Ignore())
                .ForMember(e => e.CreateAt, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RoomCreateInput, RoomDto>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ReverseMap();

            // CreateMap<RoomDto, RoomCreateInput>();
        }
    }
}
