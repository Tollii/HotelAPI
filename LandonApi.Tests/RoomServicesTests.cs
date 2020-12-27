using System;
using System.Collections.Generic;
using LandonApi.Models;
using Xunit;
using LandonApi.Services;
using Microsoft.EntityFrameworkCore;

namespace LandonApi.Tests
{
    public class RoomServicesTest
    {


        [SetUp]
        public void Setup()
        {
            var rooms = new List<RoomEntity>()
            {
                new RoomEntity
                    {
                        Id = Guid.Parse("7638099e-92ba-4630-afd6-2e4284ed01c4"),
                        Name = "Oxford Suite",
                        Rate = 10119
                    },
                new RoomEntity
                    {
                        Id = Guid.Parse("301df04d-8679-4b1b-ab92-0a586ae53d08"),
                        Name = "triks Suite",
                        Rate = 234234
                    },
                new RoomEntity
                    {
                        Id = Guid.Parse("3ef0b72f-7c32-4881-805a-2e0169366f92"),
                        Name = "wowowowo",
                        Rate = 123123
                    },
                new RoomEntity
                    {
                        Id = Guid.Parse("ab108e0c-3b70-4f03-84f3-f6631e595069"),
                        Name = "tiojwet Suite",
                        Rate = 34633
                    }
            };

        }
        
        [Fact]
        public void GetRooms()
        {

        }
    }
}