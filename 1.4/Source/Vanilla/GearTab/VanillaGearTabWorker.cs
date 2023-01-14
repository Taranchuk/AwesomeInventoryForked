// <copyright file="VanillaGearTabWorker.cs" company="Zizhen Li">
// Copyright (c) Zizhen Li. All rights reserved.
// Licensed under the GPL-3.0-only license. See LICENSE.md file in the project root for full license information.
// </copyright>

using RimWorld;
using System;

namespace AwesomeInventory.UI
{
    public class AwesomeInventoryTab : AwesomeInventoryTabBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AwesomeInventoryTab"/> class.
        /// </summary>
        [Obsolete(ErrorText.NoDirectCall, false)]
        public AwesomeInventoryTab()
            : base()
        {
            _drawGearTab = new VanillaGearTabWorker(this);
        }
    }
    public class VanillaGearTabWorker : DrawGearTabWorker
    {
        public VanillaGearTabWorker(ITab_Pawn_Gear gearTab) : base(gearTab)
        {
        }
    }
}
