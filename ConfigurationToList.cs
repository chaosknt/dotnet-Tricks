var configurationList = configuration.AsEnumerable()
    //.Where(kv => kv.Key == "LOG_LEVEL_SYS")
    .Where(kv => string.IsNullOrWhiteSpace(kv.Value))
    .Select(kv => new { Key = kv.Key, Value = kv.Value })
    .ToList();
