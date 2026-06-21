using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dometrain.EFCore.API.Data.EntityMapping;

public class DateTimeToChar8Converter()
    : ValueConverter<DateTime, string>(
        dateTime => dateTime.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
        stringValue => DateTime.ParseExact(stringValue, "yyyyMMdd", CultureInfo.InvariantCulture)
    );
