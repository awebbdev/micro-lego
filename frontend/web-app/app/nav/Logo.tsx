'use client'

import { useParamsStore } from '@/hooks/useParamsStore'
import React from 'react'
import { TbLego } from "react-icons/tb";

export default function Logo() {
    const reset = useParamsStore(state => state.reset);

    return (
        <div onClick={reset} className='cursor-pointer flex items-center gap-2 text-3xl font-semibold text-blue-600'>
            <TbLego size={34} />
            <div>LegoBay Auctions</div>
        </div>
    )
}
