﻿namespace MyWebApi.Builders.Actions
{
    using System;
    using Contracts.Models;
    using Models;

    /// <summary>
    /// Class containing methods for testing return type.
    /// </summary>
    /// <typeparam name="TActionResult">Result from invoked action in ASP.NET Web API controller.</typeparam>
    public partial class ActionResultTestBuilder<TActionResult>
    {
        /// <summary>
        /// Tests whether action result is of the provided type.
        /// </summary>
        /// <param name="returnType">Expected response type.</param>
        /// <returns>Response model details test builder.</returns>
        public IModelDetailsTestBuilder<TActionResult> ShouldReturn(Type returnType)
        {
            this.ValidateActionReturnType(returnType, true, true);
            return new ModelDetailsTestBuilder<TActionResult>(
                this.Controller,
                this.ActionName,
                this.CaughtException,
                this.ActionResult);
        }

        /// <summary>
        /// Tests whether action result is of the provided generic type.
        /// </summary>
        /// <typeparam name="TResponseModel">Expected response type.</typeparam>
        /// <returns>Response model test builder.</returns>
        public IModelDetailsTestBuilder<TActionResult> ShouldReturn<TResponseModel>()
        {
            this.ValidateActionReturnType<TResponseModel>(true);
            return new ModelDetailsTestBuilder<TActionResult>(
                this.Controller,
                this.ActionName,
                this.CaughtException,
                this.ActionResult);
        }

        private TReturnObject GetReturnObject<TReturnObject>()
            where TReturnObject : class 
        {
            this.ValidateActionReturnType<TReturnObject>(true);
            return this.ActionResult as TReturnObject;
        }
    }
}
