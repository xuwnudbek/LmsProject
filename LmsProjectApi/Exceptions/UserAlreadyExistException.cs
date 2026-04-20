using System;

namespace LmsProjectApi.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException()
        { }

        public UserAlreadyExistException(string username)
            : base()
        { }

        public UserAlreadyExistException(string username, Exception innerException) 
            : base($"User {username} already exists", innerException)
        { }
    }
}
