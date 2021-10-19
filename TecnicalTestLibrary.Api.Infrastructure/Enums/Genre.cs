using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TecnicalTestLibrary.Api.Infrastructure.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Genre
    {
        ActionAndAdventure = 1,
        Classics = 2,
        ComicBook = 3,
        Mystery = 4,
        Fantasy = 5,
        HistoricalFiction = 6,
        Horror = 7,
        LiteraryFiction = 8,
        Romance = 9,
        ScienceFiction = 10,
        SuspenseAndThrillers = 11,
        BiographiesAndAutobiographies = 12,
        History = 13,
        SelfHelp = 14
    }
}
