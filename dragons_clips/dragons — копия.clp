;========================================================================
; Этот блок реализует логику обмена информацией с графической оболочкой,
; а также механизм остановки и повторного пуска машины вывода
; Русский текст в комментариях разрешён!

(deftemplate ioproxy  ; шаблон факта-посредника для обмена информацией с GUI
	(slot fact-id)        ; теоретически тут id факта для изменения
	(multislot answers)   ; возможные ответы
	(multislot messages)  ; исходящие сообщения
	(slot reaction)       ; возможные ответы пользователя
	(slot value)          ; выбор пользователя
	(slot restore)        ; забыл зачем это поле
)

; Собственно экземпляр факта ioproxy
(deffacts proxy-fact
	(ioproxy
		(fact-id 0112) ; это поле пока что не задействовано
		(value none)   ; значение пустое
		(messages)     ; мультислот messages изначально пуст
	)
)

(defrule clear-messages
	(declare (salience 90))
	?clear-msg-flg <- (clearmessage)
	?proxy <- (ioproxy)
	=>
	(modify ?proxy (messages))
	(retract ?clear-msg-flg)
	(printout t "Messages cleared ..." crlf)	
)

(defrule set-output-and-halt
	(declare (salience 99))
	?current-message <- (sendmessagehalt ?new-msg)
	?proxy <- (ioproxy (messages $?msg-list))
	=>
	(printout t "Message set : " ?new-msg " ... halting ..." crlf)
	(modify ?proxy (messages ?new-msg))
	(retract ?current-message)
	(halt)
)

(defrule append-output-and-halt
	(declare (salience 99))
	?current-message <- (appendmessagehalt $?new-msg)
	?proxy <- (ioproxy (messages $?msg-list))
	=>
	(printout t "Messages appended : " $?new-msg " ... halting ..." crlf)
	(modify ?proxy (messages $?msg-list $?new-msg))
	(retract ?current-message)
	(halt)
)

(defrule set-output-and-proceed
	(declare (salience 99))
	?current-message <- (sendmessage ?new-msg)
	?proxy <- (ioproxy)
	=>
	(printout t "Message set : " ?new-msg " ... proceed ..." crlf)
	(modify ?proxy (messages ?new-msg))
	(retract ?current-message)
)

(defrule append-output-and-proceed
	(declare (salience 99))
	?current-message <- (appendmessage ?new-msg)
	?proxy <- (ioproxy (messages $?msg-list))
	=>
	(printout t "Message appended : " ?new-msg " ... proceed ..." crlf)
	(modify ?proxy (messages $?msg-list ?new-msg))
	(retract ?current-message)
)

; это правило не работает - исправить (тут нужна печать списка)
(defrule print-messages
	(declare (salience 99))
	?proxy <- (ioproxy (messages ?msg-list))
	?update-key <- (updated True)
	=>
	(retract ?update-key)
	(printout t "Messages received : " ?msg-list crlf)
)

;======================================================================================
(deftemplate dragon 
	(multislot name) 
	(slot category)
	(slot color)
	(slot location)
	(slot feature)
	(slot goal)
	(slot weather)
    (slot fire)
)

(defrule greeting
   =>
   (printout t "Hello! " crlf)
)


(defrule r1
	(declare (salience 20))
	?p1 <-	(dragon (name ?name1) 
	)
	(test (> (abs (str-length ?name1)) 1))
	;(test (< (fact-index ?p1) (fact-index ?p2)))
	=> 
	(assert (appendmessagehalt (str-cat "У нас есть Дракон! Имя = " ?name1 ))); " | Цвет = " ?color1 " | Категория = " ?category1 " | Локация = " ?location1)))
)

(defrule match-dragon-for-user 
	(declare (salience 10))
	=> 
	(assert (sendmessagehalt "Дракон не нашёлся, но вы там держитесь!"))
) 

; скрилл
(defrule r10
	(declare (salience 30))
	?p1 <-	(dragon 
		(category ?category1&Разящие) 
		(color ?color1)
		(location ?location1&Горы)
	)
	=> 
	(assert (dragon (name "Скрилл") (category ?category1) (color ?color1) (location ?location1)))
	;(assert (appendmessagehalt (str-cat "Cat = " ?category1)))
)

; ночная фурия
(defrule r3
	(declare (salience 30))
	?p1 <-	(dragon 
		(category ?category1) 
		(color ?color1&Черный)
		(location ?location1&Неизвестно)
	)
	=> 
	(assert (dragon (name "Ночная фурия") (category ?category1) (color ?color1) (location ?location1)))
	;(assert (appendmessagehalt (str-cat "Cat = " ?category1)))
)

; неизвестно -> горы
(defrule r0
	(declare (salience 30))
	?p1 <-	(dragon (name ?name1)
		(category ?category1) 
		(color ?color1)
		(location ?location1&Неизвестно)		
	)
	=> 
	(assert (dragon (name ?name1) (category ?category1) (color ?color1) (location Горы)))
	;(assert (appendmessagehalt (str-cat "Cat = " ?category1)))
)

(defrule add-fact 
	(declare (salience 35))
	=> 
	(assert (dragon (color Черный) (category Разящие) (location Горы)))
	;(assert (appendmessagehalt (str-cat "Color = " "black")))
) 