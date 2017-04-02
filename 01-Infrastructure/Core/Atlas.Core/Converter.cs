using System;

namespace Atlas.Core
{
    public static class Converter
    {
        public static dynamic ChangeTo(dynamic source, Type dest)
        {
            return System.Convert.ChangeType(source, dest);
        }
    }
}
