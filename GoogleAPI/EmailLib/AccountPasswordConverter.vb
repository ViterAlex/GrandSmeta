﻿Imports System.ComponentModel
Imports System.Globalization
Imports System.Security
Imports System.Windows.Forms

''' <summary>
'''     Класс для представления пароля в <see cref="PropertyGrid"/>.
''' </summary>
''' <remarks>
''' Пароль хранится  в виде <see cref="SecureString"/>, поэтому для редактирования в <see cref="PropertyGrid"/>
''' его нужно преобразовывать в <see cref="String"/> и обратно.
''' </remarks>
Public Class AccountPasswordConverter
    Inherits StringConverter

#Region "Public Methods"

    Public Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As CultureInfo, value As Object) As Object
        'Пользователь вводит обычную строку. Она преобразовывается в SecureString и затем в base64 для хранения
        Return value.ToString().
            ToSecure().
            ToBase64()
    End Function

    Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object, destinationType As Type) As Object
        'Пароль хранится в виде base64 строки. Поэтому для отображения в PropertyGrid нужно его перевести сначала
        'в SecureString, затем в обычную строку
        Return value.ToString().
            FromBase64().
            ToUnsecure()
    End Function

#End Region

End Class