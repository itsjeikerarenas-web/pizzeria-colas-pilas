# 🍕 Práctica Evaluada: Pizzería Campus Express
**Gestión de Pedidos con Colas y Pilas en C# / WinForms**

## 🎯 Objetivo
Implementar un sistema de gestión de pedidos que respete el orden de llegada (FIFO) y permita revertir la última acción del operador (LIFO), utilizando colecciones de .NET y entregando el trabajo mediante un flujo profesional de Git.

## 📖 Escenario
Trabajas en el sistema de una pizzería universitaria:
- **🚲 Cola de Pedidos (`Queue`)**: Los clientes llaman y sus pedidos se registran. Por norma de la casa, **se preparan y entregan estrictamente por orden de llegada**.
- **📦 Pila de Bitácora (`Stack`)**: Cada acción del operador se registra. Si hay un error, el botón **"Deshacer"** revierte **la última acción realizada**.

## ⚙️ Requerimientos Técnicos
| Componente | Especificación |
|------------|----------------|
| **Colecciones** | `System.Collections.Generic` (`Queue<string>`, `Stack<string>`) |
| **Formato de texto** | Usar exclusivamente `string.Format()`. |
| **Interfaz** | WinForms con `txtCliente`, `lstPedidos`, `lstBitacora`, `lblEstado`, `lblContador` y botones de acción |
| **Entrega** | Fork → Commits ≥3 → Pull Request al repositorio base |

## 🛠️ Guía de Implementación (Paso a Paso)
> 📌 Sigue este orden lógico. Los comentarios en `Form1.cs` te marcarán exactamente dónde escribir cada bloque.

1. **Nuevo Pedido (Entrada FIFO)**
   - Lee y limpia el texto del cliente.
   - Si está vacío, muestra advertencia en `lblEstado` usando `string.Format()` y detén la ejecución.
   - Agrega el cliente a la cola.
   - Registra la acción en la pila con prefijo `"PEDIDO: "`.
   - Actualiza la interfaz.

2. **Preparar/Entregar (Salida FIFO)**
   - Valida que haya pedidos pendientes. Si no, informa y retorna.
   - Extrae el primer cliente de la cola.
   - Registra `"ENTREGADO: {cliente}"` en la pila.
   - Refresca la UI y muestra confirmación.

3. **Deshacer Última Acción (Lógica LIFO)**
   - Si la bitácora está vacía, informa y retorna.
   - Extrae la última acción registrada.
   - Analiza el prefijo:
     - Si fue `"PEDIDO:"` → El cliente **nunca salió** de la cola. Debes reconstruir la cola excluyendo ese registro (pista: usa `ToArray()`, limpia la cola original y vuelve a `Enqueue()` solo los elementos que no coincidan).
     - Si fue `"ENTREGADO:"` → El cliente **ya fue despachado**. Debes volver a encolarlo extrayendo su nombre del texto.
   - Muestra qué se revirtió y sincroniza la interfaz.

4. **Sincronizar Interfaz**
   - Limpia ambos `ListBox`.
   - Itera la cola y la pila, agregando cada elemento a su respectivo `ListBox`.
   - Actualiza `lblContador` con `string.Format("Pedidos: {0} | Bitácora: {1}", cola.Count, pila.Count)`.
   - Si la cola está vacía, agrega un placeholder visual: `"(Sin pedidos pendientes)"`.

## 🌐 Flujo Git para Entrega
1. Haz **Fork** de este repositorio.
2. Clona este fork y abre el `.sln` en SharpDevelop.
3. Implementa la lógica siguiendo los `TODO` de `MainForm.cs`.
4. Realiza **mínimo 3 commits** descriptivos (`feat:`, `fix:`, `docs:`).
5. Haz `git push` y abre un **Pull Request** a este repositorio.
6. En la descripción del PR, responde las **4 Preguntas de Comprensión** y adjunta una captura de la app funcionando.

## ❓ Preguntas de Comprensión (Obligatorias en el PR)
1. ¿Por qué un sistema de delivery usa `Queue` para los pedidos pero `Stack` para la bitácora? ¿Qué problema surgiría si invertimos las estructuras?   
R:  Pedidos = Queue (Cola / Primero en entrar, primero en salir): Es por pura justicia y logística. El cliente que pide primero, recibe su comida primero. Nadie se cuela.
Bitácora = Stack (Pila / Último en entrar, primero en salir): Es por relevancia. Si el sistema falla, al programador le interesa ver lo último que pasó (lo que está arriba de la pila), no lo que pasó hace tres días.
Pedidos en Stack: El último cliente en pedir comería primero, mientras que el primero se quedaría al fondo de la pila esperando eternamente y su comida se enfriaría.

Bitácora en Queue: Para revisar el error que acaba de ocurrir hace dos segundos, tendrías que leer todo el historial de la app desde el primer día, perdiendo horas en buscar lo más reciente.

2. ¿Por qué es obligatorio verificar `Count == 0` antes de `Dequeue()` o `Pop()`? ¿Qué ocurre en ejecución si se omite?  

R:Es obligatorio porque si intentas sacar un elemento de una cola o pila que está vacía, el sistema no encuentra nada que procesar y lanza un error crítico de ejecución (como un InvalidOperationException o IndexOutOfBound).

Si omites esta verificación, la aplicación se va a congelar o cerrar inesperadamente (un crash), arruinando la experiencia del usuario y deteniendo el flujo del sistema de delivery. Por eso, siempre se revisa que Count > 0 antes de operar.

3. En el método `Deshacer`, ¿por qué es necesario analizar el texto con `.StartsWith()` antes de revertir? ¿Qué error lógico evitaría esto? 

Se usa .StartsWith() para asegurarte de qué estás deshaciendo (por ejemplo, checar si el texto dice "Pedido #..." antes de borrarlo).

El error que evita es que borres lo que no debes. Si sacas el último cambio a lo loco y a ciegas, podrías deshacer una alerta del sistema o un pago en lugar de la acción del usuario, dejando la app desincronizada y con datos totalmente equivocados.

4. ¿Qué ventaja tiene entregar mediante Fork + Pull Request en lugar de un archivo comprimido? ¿Cómo facilita la la retroalimentación?

Las ventajas son:

Cero desorden: No hay que estar descargando archivos, descomprimiendo, ni lidiando con el típico "proyecto_final_este_si_v2.zip". Todo el código está en la nube, limpio y ordenado.

Ves los cambios exactos: El evaluador puede ver línea por línea qué agregaste, qué borraste y qué modificaste (los famosos diffs).

¿Cómo facilita la retroalimentación?
Es muchísimo más fácil porque el feedback es quirúrgico: el evaluador puede dejarte un comentario directamente en la línea de código que está mal o que se puede mejorar. Tú le puedes responder ahí mismo, corregir el código, subir el cambio, y el PR se actualiza solo sin tener que volver a mandar otro archivo.


## ✅ Checklist de Entrega
- [ ] Código compila en SharpDevelop sin warnings críticos
- [ ] Uso correcto y consistente de `string.Format()` en todos los mensajes
- [ ] Botón `Deshacer` revierte correctamente ambos casos
- [ ] ≥3 commits con mensajes claros
- [ ] PR abierto con respuestas + captura

📥 **Entrega:** Pull Request. Fecha límite: fin de la sesión de laboratorio.
