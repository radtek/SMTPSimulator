//-------------------------------------------------------------------------------
// <copyright file="INamedItem.cs" company="bbv Software Services AG">
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

namespace bbv.Common.EventBroker
{
    /// <summary>
    /// <see cref="INamedItem"/> is used to give publishers or subscribers names to use scope matchers.
    /// </summary>
    public interface INamedItem
    {
        /// <summary>
        /// Gets the name of the event broker item that is used for scope matchers.
        /// </summary>
        /// <value>The name of the event broker item.</value>
        string EventBrokerItemName { get; }
    }
}