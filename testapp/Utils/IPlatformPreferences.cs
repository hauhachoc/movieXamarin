using System;
using System.Collections.ObjectModel;
using testapp.Models.Response;

namespace testapp.Utils
{
    public interface  IPlatformPreferences
    {
		Collection<Film> getUserInfo();
    }
}
