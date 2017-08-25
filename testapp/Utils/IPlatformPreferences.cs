using System;
using System.Collections.ObjectModel;

namespace testapp.Utils
{
    public interface  IPlatformPreferences
    {
		Collection<string> getUserInfo();

		void saveUserInfo(Collection<string> users);

		void clearUserInfo();
    }
}
