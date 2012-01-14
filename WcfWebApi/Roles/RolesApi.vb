Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.Http
Imports System.ServiceModel
Imports System.ServiceModel.Web
Imports System.Web
Imports WcfWebApi.Roles.Infrastructure
Imports WcfWebApi.Roles.Models
Imports Microsoft.ApplicationServer.Http.Dispatcher

Namespace Roles
    <ServiceContract()>
    Public Class RolesApi
        Private ReadOnly _repo As IRolesRepository

        Public Sub New(ByVal repo As IRolesRepository)
            _repo = repo
        End Sub

        <WebGet()>
        Public Function GetRole() As HttpResponseMessage(Of IQueryable(Of Role))
            Dim model = _repo.GetAll()
            Dim responseMessage = New HttpResponseMessage(Of IQueryable(Of Role))(model)
            responseMessage.Content.Headers.Expires = New DateTimeOffset(DateTime.Now.AddHours(6))

            Return responseMessage
        End Function

        <WebGet(UriTemplate:="{id}")>
        Public Function GetSingle(ByVal id As Integer) As HttpResponseMessage(Of Role)
            Dim role = _repo.GetSingle(id)

            If role Is Nothing Then
                Dim response = New HttpResponseMessage
                response.StatusCode = Net.HttpStatusCode.NotFound
                response.Content = New StringContent("Not Found")
                Throw New HttpResponseException(response)
            End If

            Dim roleResponse = New HttpResponseMessage(Of Models.Role)(role)
            roleResponse.Content.Headers.Expires = New DateTimeOffset(DateTime.Now.AddHours(6))
            Return roleResponse
        End Function
    End Class
End Namespace
