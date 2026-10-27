using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MidtermExam.Prob01
{
    public class VowelCounter
    {
        /// <summary>
        /// ข้อ 01: นับจำนวนสระภาษาอังกฤษตัวพิมพ์เล็กในคิว โดยใช้หลัก FIFO
        /// (สมาชิกที่เข้าก่อนออกก่อน) และรักษาสมาชิกกับลำดับของคิวเดิม
        /// </summary>
        /// <param name="alphabets">
        /// คิวข้อความที่ต้องการตรวจ นับเฉพาะ "a", "e", "i", "o", "u" และนับตัวซ้ำทุกตัว
        /// ข้อความอื่น เช่น "A", "ae", ข้อความว่าง และสมาชิก null ไม่นับเป็นสระ
        /// </param>
        /// <returns>จำนวนสระทั้งหมด หรือ 0 เมื่อคิวเป็น null หรือไม่มีสมาชิก</returns>
        /// <remarks>
        /// ตัวแปร Queue<string> alphabets หลังจากจบ function จะต้องยังคงข้อมูลให้เหมือนเดิมทั้งจำนวนและลำดับ
        /// HINT: อ่านข้อมูลด้วย Dequeue() และใส่กลับด้วย Enqueue() ในคิวที่รับมา
        /// ตัวอย่าง: ["a", "b", "e", "a"] จะต้อง return 3 
        /// และคิวหลังเรียกยังเป็น ["a", "b", "e", "a"] เหมือนเดิม
        /// </remarks>
        public int AS01_CountVowels(Queue<string> alphabets)
        {
            // TODO: เขียนคำตอบแทนคำสั่ง throw exception ด้านล่าง
            if (alphabets == null)
                return 0;
            
            string[] vowels = new string[5];
            vowels[0] = "a";
            vowels[1] = "e";
            vowels[2] = "i";
            vowels[3] = "o";
            vowels[4] = "u";

            int amount = 0;
            string alphabets_check;
            Queue<string> newQueue = new Queue<string>();

            for (int i = 0; i < alphabets.Count; i++)
            {
                alphabets_check = alphabets.Dequeue();
                newQueue.Enqueue(alphabets_check);
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (alphabets_check == vowels[j])
                    {
                        amount++;
                    }
                }
            }

            for (int i = 0; i < newQueue.Count; i++)
            {
                alphabets.Enqueue(newQueue.Dequeue());
            }

            return amount;
        }
    }
}
