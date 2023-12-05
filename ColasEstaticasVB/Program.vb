Imports System

Module Program
    Dim miCola As Integer() = New Integer(9) {} ' Tamaño fijo del arreglo para la cola
    Dim frente As Integer = -1
    Dim fin As Integer = -1
    Sub Main(args As String())
        Dim a As Integer = 1

        Do
            Console.WriteLine("Seleccione una operación:")
            Console.WriteLine("1. Agregar elemento a la cola")
            Console.WriteLine("2. Eliminar elemento de la cola")
            Console.WriteLine("3. Imprimir la cola")
            Console.WriteLine("4. Salir")

            Dim opcion As Integer
            If Integer.TryParse(Console.ReadLine(), opcion) Then
                Console.Clear()
                Select Case opcion
                    Case 1
                        Console.Write("Ingrese el elemento a agregar: ")
                        Dim entrada As String = Console.ReadLine()
                        Dim elementoAgregar As Integer

                        If Integer.TryParse(entrada, elementoAgregar) Then
                            EnqueueElemento(elementoAgregar)
                        Else
                            Console.WriteLine("Por favor, ingrese un valor entero válido.")
                        End If
                    Case 2
                        DequeueElemento()
                    Case 3
                        ImprimirCola()
                    Case 4
                        Console.WriteLine("Saliendo del programa.")
                        a = 2
                    Case Else
                        Console.WriteLine("Opción no válida. Intente nuevamente.")
                End Select
            Else
                Console.WriteLine("Por favor, ingrese un número válido.")
            End If

        Loop While a = 1
    End Sub

    ' Método para insertar elementos en la cola
    Sub EnqueueElemento(elemento As Integer)
        If fin = miCola.Length - 1 Then
            Console.WriteLine("La cola está llena. No se puede agregar más elementos.")
        Else
            fin += 1
            miCola(fin) = elemento
            Console.WriteLine($"Se agregó el elemento {elemento} a la cola.")
        End If

        If frente = -1 Then
            frente = 0
        End If
    End Sub

    ' Método para eliminar un elemento de la cola
    Sub DequeueElemento()
        If frente = -1 Then
            Console.WriteLine("La cola está vacía. No se puede eliminar ningún elemento.")
        Else
            Dim elementoEliminado As Integer = miCola(frente)
            Console.WriteLine($"Se eliminó el elemento {elementoEliminado} de la cola.")
            frente += 1

            If frente > fin Then
                frente = -1
                fin = -1
            End If
        End If
    End Sub

    ' Método para imprimir la cola
    Sub ImprimirCola()
        If frente = -1 Then
            Console.WriteLine("La cola está vacía.")
        Else
            Console.Write("Contenido de la cola: ")
            For i As Integer = frente To fin
                Console.Write(miCola(i) & " ")
            Next
            Console.WriteLine()
        End If
    End Sub

End Module
