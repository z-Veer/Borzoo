﻿using System.ComponentModel.DataAnnotations;
using Borzoo.Data.Abstractions.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Borzoo.GraphQL.Models
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class TaskListCreationDto
    {
        [Required]
        [MinLength(1)]
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [JsonProperty(Required = Required.Always)]
        public string Title { get; set; }

        public static explicit operator TaskList(TaskListCreationDto dto) =>
            dto is null
                ? null
                : new TaskList
                {
                    DisplayId = dto.Name,
                    Title = dto.Title,
                };
    }
}