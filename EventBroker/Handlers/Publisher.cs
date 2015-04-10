//-------------------------------------------------------------------------------
// <copyright file="Publisher.cs" company="bbv Software Services AG">
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

namespace bbv.Common.EventBroker.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Handler that executes the subscription on the same thread the publisher is currently running (synchronous).
    /// </summary>
    public class Publisher : IHandler
    {
        /// <summary>
        /// Initalizes the handler. Nothing to initialize for <see cref="Publisher"/>.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="handlerMethodName">Name of the handler method on the subscriber.</param>
        /// <param name="parameterTypes">The parameter types of the handler method on the subscriber.</param>
        public void Initalize(object subscriber, string handlerMethodName, Type[] parameterTypes)
        {
            // there is nothing to initialize
        }

        /// <summary>
        /// Executes the subscription synchronously on the same thread as the publisher is currently running.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <param name="subscriptionHandler">The subscription handler.</param>
        /// <param name="exceptions">The exceptions that occured during the execution. For implementors: Add exception here, Handle must not throw exceptions.</param>
        public void Handle(object sender, EventArgs e, Delegate subscriptionHandler, ICollection<Exception> exceptions)
        {
            try
            {
                subscriptionHandler.DynamicInvoke(sender, e);
            }
            catch (TargetInvocationException ex)
            {
                exceptions.Add(ex.InnerException);
            }
        }
    }
}