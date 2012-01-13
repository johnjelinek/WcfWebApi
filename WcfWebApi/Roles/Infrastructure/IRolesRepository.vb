Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports WcfWebApi.Roles.Models

Namespace Roles.Infrastructure
    Public Interface IRolesRepository

        Function GetAll() As IQueryable(Of Role)
        Function GetSingle(ByVal id As Integer) As Role

    End Interface
End Namespace
