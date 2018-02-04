using System.Text;

namespace Generics
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    /// <inheritdoc />
    /// <summary>
    /// Класс представляет собой LinkedList с уникальными значениями T.
    /// </summary>
    /// <typeparam name="T"></typeparam>


    public sealed class MyGenListUnique <T> : ICollection<T> // Что происходит с интерфейсами: Коллекция - это IEnumerable<T> + IEnumerable. То есть универсальный + неуниверсальный(возвращает IEnumerator который все конвертирует в object) интерфейс "Для перечислителя". У них всего один метод, GetEnumerator(). Отличаются тем, что универсальный возвращает IEnumerable<T>, а неуниверсальный - IEnumerable. Неуниверсальный: Current is object. Универсальный: Current is T.
    {
        private Node <T> firstNode, lastNode, currentNode;

        public MyGenListUnique() {}

        public MyGenListUnique(IEnumerable <T> collecton) // коллекция - и так IEnumerable
        {
            // конструктор копирования
            if (collecton is null)
            {
                return;
            }
            
            foreach (var t in collecton)
            {
                Add(t);
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; } = false; // не хочу реализовывать IsReadOnly, мне это не нужно пока. Вроде.

        #region publicMethods

        public void Add(T item)
        {
            if (firstNode is null)
            {
                // may be only if they are both null
                firstNode = new Node <T>(item, null, null);
                lastNode  = firstNode;
                return ;
            }

            if (!this.Contains(item))
            {
                lastNode.Next = new Node <T>(item, lastNode, null);
                lastNode      = lastNode.Next;
                IncreaseCount();
                return ;
                
            }
        }


        /// <summary>
        /// Добавляет после элемента, если он есть. Добавляет в конец, если его нет.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="after"></param>
        public bool AddAfter(T item, T after)
        {
            if (this.Contains(item))
            {
                return false;
            }

            foreach (var t in this) // где-то здесь вылетает
            {
                if (t.Equals(after))
                {
                    currentNode.Next = new Node <T>(item, currentNode, currentNode.Next);
                    if (currentNode == lastNode)
                        lastNode = lastNode.Next;
                    return true;
                }
            }
            
            lastNode.Next = new Node <T>(item, lastNode, null);
            lastNode      = lastNode.Next;
            return true;
        }

        /// <summary>
        /// Добавляет до элемента, если он есть. Добавляет в начало, если его нет.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="before"></param>
        public bool AddBefore(T item, T before) // С этим еще придется разобраться. Завтра.
        {
            if (this.Contains(item))
            {
                return false;
            }

            foreach (var t in this)
            {
                if (!t.Equals(before))
                    continue;
                var addedNode = new Node <T>(item, currentNode.Prev, currentNode);
                if(currentNode.Prev!=null)
                    currentNode.Prev.Next = addedNode;

                currentNode.Prev = addedNode;
                if (currentNode == firstNode)
                    firstNode = firstNode.Prev;
                return true;
            }

            // знаю, лишние строки, но так лучше читается.
            firstNode.Prev = new Node <T>(item, null, firstNode);
            firstNode      = firstNode.Prev;
            return true;
        }
        /// <summary>
        /// Метод добавления сразу нескольких элементов в коллекцию. Возвращает кол-во добавленных элементов.
        /// </summary>
        /// <param name="items"></param>
        public int AddRange(T[] items)
        {
            if (items is null)
            {
                return 0;
            }

            var countAdded = 0;
            foreach (var t in items)
            {
                var currCount = Count;
                Add(t);
                if (currCount < Count)
                    countAdded++;
            }

            return countAdded;
        }

        public void Clear()
        {
            firstNode = lastNode = null;
            Count     = 0;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            foreach (var t in this)
            {
                if (t.Equals(item))
                    return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator <T> GetEnumerator()
        {
            currentNode = firstNode;
            while (currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }

            currentNode = firstNode;
        }

        public bool Remove(T item)
        {
            foreach (var t in this)
            {
                if (t.Equals(item))
                {
                    if (currentNode == firstNode)
                    {
                        if (Count == 1)
                        {
                            this.Clear();
                            return true;
                        }

                        firstNode = firstNode.Next;
                    }
                    else
                        currentNode.Prev.Next = currentNode.Next;

                    Count--;
                    return true;
                }
            }

            return false;
        }

        public int RemoveRange(T[] items)
        {
            if (items is null || items.Length==0)
            {
                return 0;
            }

            var countDeleted = 0;
            // возвращает кол-во удаленных элементов
            foreach (var item in items)
            {
                if (this.Remove(item))
                    countDeleted++;
            }

            this.Count -= countDeleted;
            return countDeleted;
        }

        
        public new string ToString()
        {
            var sb = new StringBuilder(100);
            sb.Append("{ ");
            foreach (var t in this)
            {
                sb.Append(t + " ");
            }

            sb.Append("}");

            return sb.ToString();
        }

            #endregion

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); // Get неуниверсального ссылается Get универсального.

        private void DecreaseCount(int count = 1)
        {
            Count -= count;
        }

        private void IncreaseCount(int count = 1)
        {
            Count += count;
        }

        private class Node <T>
        { 
            public T Data;

            public Node <T> Next { get; set; }

            public Node <T> Prev { get; set; }

            public Node() {}
            public Node(T data, Node <T> prev, Node <T> next)
            {
                Data = data;
                Next = next;
                Prev = prev;
            }  
        }
    }
}