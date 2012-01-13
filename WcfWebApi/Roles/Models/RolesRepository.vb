Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports WcfWebApi.Roles.Infrastructure

Namespace Roles.Models
    Public Class RolesRepository
        Implements IRolesRepository

        Public Function GetAll() As IQueryable(Of Role) Implements IRolesRepository.GetAll
            Dim roles As IList(Of Role) = New List(Of Role)

            For i As Integer = 1 To 10
                roles.Add(New Role With {
                          .ID = i _
                        , .Name = String.Format("{0}_{1}", "Role", i)})
            Next

            Return roles.AsQueryable
        End Function

        Public Function GetSingle(ByVal id As Integer) As Role Implements IRolesRepository.GetSingle
            Dim role = GetAll().SingleOrDefault(Function(x) x.ID = id)
            Return role
        End Function

    End Class
End Namespace
