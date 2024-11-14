using Application.Dtos;
using AutoMapper;
using FinalTestDomain.Models;
using FinalTestDomain.ValueObject;
using System.Linq;

namespace Application.Mapping
{
    public class MonitoringProfile : Profile
    {
        public MonitoringProfile()
        {
            // User mapping
            CreateMap<User, UserDto>().ReverseMap();

            // GeoLocation mapping
            CreateMap<GeoLocation, GeoLocationDto>().ReverseMap();

            // Sensor mapping, including GeoLocation as nested property
            CreateMap<Sensor, SensorDto>()
                .ForMember(dest => dest.GeoLocation, opt => opt.MapFrom(src => src.GeoLocation))
                .ReverseMap()
                .ForMember(dest => dest.GeoLocation, opt => opt.MapFrom(src => src.GeoLocation));

            // SensorData mapping
            CreateMap<SensorData, SensorDataDto>().ReverseMap();

            // Notification mapping
            CreateMap<Notification, NotificationDto>().ReverseMap();

            // Building mapping
            CreateMap<Building, BuildingDto>()
                .ForMember(dest => dest.SensorIds, 
                    opt => opt.MapFrom(src => src.Sensors.Select(s => s.Id).ToList())) // Mapping Sensor list to SensorIds
                .ReverseMap()
                .ForMember(dest => dest.Sensors,
                    opt => opt.Ignore()); // Sensors should be mapped separately if needed
        }
    }
}