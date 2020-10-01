using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObjects
{
    public class UserMapper
    {
        private IMapper mMapper;

        public UserMapper()
        {
            mMapper = new MapperConfiguration(config => 
            {
                config.CreateMap<UserEntity, UserDto>()
                      .ForMember(x => x.IsUserAboveEighteen, y => y.MapFrom(z => z.Age >18))
                      .ReverseMap();
                
                config.CreateMap<UserDto, UserViewModel>()
                      .ReverseMap();
                

            }).CreateMapper();
        }

        public UserDto Map(UserEntity userEntity) => mMapper.Map<UserDto>(userEntity);
        public UserEntity ReverseMap(UserDto userDto) => mMapper.Map<UserEntity>(userDto);
        public UserViewModel Map(UserDto userDto) => mMapper.Map<UserViewModel>(userDto);
        public UserDto ReverseMap(UserViewModel userViewModel) => mMapper.Map<UserDto>(userViewModel);

    }
}
