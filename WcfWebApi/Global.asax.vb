Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Routing
Imports System.Web.Security
Imports System.Web.SessionState
Imports Ninject

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        RouteTable.Routes.SetDefaultHttpConfiguration(New Microsoft.ApplicationServer.Http.WebApiConfiguration() With
        {
            .CreateInstance = Function(serviceType, context, request) _
                              GetKernel().Get(serviceType)
        })

        RouteTable.Routes.MapServiceRoute(Of Roles.RolesApi)("Api/Roles")
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

    Private Function GetKernel() As IKernel
        Dim kernel As IKernel = New StandardKernel()

        kernel.Bind(Of Roles.Infrastructure.IRolesRepository)().To(Of Roles.Models.RolesRepository)()

        Return kernel
    End Function

End Class