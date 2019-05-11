using System;
using System.Collections.Generic;
using System.Linq;

using Maple.Domain;
using Maple.Localization.Properties;
using MvvmScarletToolkit.Abstractions;

namespace Maple.Core
{
    public sealed class SequenceService : ISequenceService
    {
        private readonly ILoggingService _log;

        public SequenceService(ILoggingService log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public int Get(IList<ISequence> items)
        {
            var result = 0;

            if (items.Count > 0)
            {
                while (items.Any(p => p.Sequence == result))
                {
                    if (result == int.MaxValue)
                    {
                        _log.Error(Resources.MaxPlaylistCountReachedException);
                        break;
                    }

                    result++;
                }
            }

            return result;
        }
    }
}
