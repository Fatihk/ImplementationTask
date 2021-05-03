using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationTask.Models
{
    /// <summary>
    /// Response generic model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; private set; }

        private bool hasError;
        /// <summary>
        /// Error state
        /// </summary>
        public bool HasError
        {
            get
            {

                if (!string.IsNullOrEmpty(this.Message))
                    this.hasError = true;
                else
                    this.hasError = false;
                return this.hasError;
            }
            private set
            {
                this.hasError = value;
            }
        }
        /// <summary>
        /// Response data
        /// </summary>
        public T Data { get; set; }
        public ApiResponse()
        {

        }
        public ApiResponse(string message)
        {
            this.Message = message;
        }
        public ApiResponse(T data, string message)
        {
            this.Data = data;
            this.Message = message;
        }

    }
}
