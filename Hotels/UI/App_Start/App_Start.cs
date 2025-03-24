//// -----------------------------------------------------------------------
//// <copyright file="App_Start.cs" company="Fluent.Infrastructure">
////     Copyright © Fluent.Infrastructure. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
/// See more at: https://github.com/dn32/Fluent.Infrastructure/wiki
////-----------------------------------------------------------------------


using UI.DataBase;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UI.App_Start), "PreStart")]

namespace UI {
    public static class App_Start {
        public static void PreStart() {
        }
    }
}