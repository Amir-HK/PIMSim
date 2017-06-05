﻿#region Reference
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePIM.Configs;
#endregion

namespace SimplePIM.General
{
    /// <summary>
    /// Instruction Block Defination
    /// Instruction Block is an input of a snippet of code.
    /// <para>Marking code snippet as Instruction Block allows you to get information about this snippet after simulation finished.</para>
    /// </summary>
    public class InstructionBlock : InputType
    {
        #region Private Variables

        /// <summary>
        /// All instructions in this block.
        /// </summary>
        private List<Instruction> ins = new List<Instruction>();

        /// <summary>
        /// Cycle when get processed.
        /// </summary>
        private UInt64 servetime = NULL;

        #endregion

        #region Public Varibles

        /// <summary>
        /// Instruction Count.
        /// </summary>
        public int ins_count=> ins.Count();
        
        /// <summary>
        /// Block name
        /// </summary>
        public string name = "";

        #endregion

        #region Public Methods

        /// <summary>
        /// Count bytes of the whole block.
        /// </summary>
        /// <returns></returns>
        public override ulong Length()
        {
            return Config.operationcode_length * (uint)ins_count;
        }

        /// <summary>
        /// Add instruction to block.
        /// </summary>
        /// <param name="ins_">Instruction</param>
        public void add_ins(Instruction ins_)
        {
            if (ins.Count == 0)
                cycle = ins_.cycle;
            ins.Add(ins_);
        }

        /// <summary>
        /// Get instructions.
        /// If instructions is fetched, pop out this instruction in the list.
        /// </summary>
        /// <param name="cycle"></param>
        /// <returns></returns>
        public Instruction get_ins(UInt64 cycle)
        {
            if (ins.Count > 0)
            {
                if (ins[0].cycle <= cycle)
                {
                    if (servetime == NULL)
                        servetime = cycle;
                    var item = ins[0];
                    ins.RemoveAt(0);
                    return item;
                }
                else
                    return new Instruction();
            }
            else
            {
                return null;
            }
        }

        #endregion 
    }
}
