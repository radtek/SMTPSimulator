//-------------------------------------------------------------------------------
// <copyright file="StaticPublisherEventException.cs" company="bbv Software Services AG">
//   Copyright (c) 2008 bbv Software Services AG
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
//   Contains software or other content adapted from 
//   Smart Client � Composite UI Application Block, 
//   2005 Microsoft Corporation. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------

namespace bbv.Common.EventBroker.Exceptions
{
    using System.Reflection;

    /// <summary>
    /// An <see cref="EventBrokerException"/> thrown when a published event is static.
    /// </summary>
    public class StaticPublisherEventException : EventBrokerException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StaticPublisherEventException"/> class.
        /// </summary>
        /// <param name="eventInfo">The event info.</param>
        public StaticPublisherEventException(EventInfo eventInfo)
            : base("Static publisher event is not allowed: '{0}.{1}'", eventInfo.DeclaringType.FullName, eventInfo.Name)
        {
        }
    }
}
